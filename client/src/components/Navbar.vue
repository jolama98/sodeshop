<script setup>
import { ref, watch } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import { AppState } from '@/AppState.js';




const theme = ref(loadState('theme') || 'light')

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
}

watch(theme, () => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}, { immediate: true })

</script>

<template>
  <nav class="navbar navbar-expand-md bg-dark border-bottom border-vue">
    <div class="container gap-2">
      <RouterLink :to="{ name: 'Home' }" class="d-flex align-items-center text-light">

        <b role="button" class="fs-5">Soda Shop</b>
      </RouterLink>
      <!-- collapse button -->
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-links"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="mdi mdi-menu text-light"></span>
      </button>
      <!-- collapsing menu -->
      <div class="collapse navbar-collapse " id="navbar-links">
        <ul class="navbar-nav">
          <li>
            <RouterLink :to="{ name: 'About' }" class="btn text-green selectable">
              About
            </RouterLink>
          </li>
        </ul>
        <!-- LOGIN COMPONENT HERE -->

        <div class="ms-auto">
          <button class="btn text-light" @click="toggleTheme"
            :title="`Enable ${theme == 'light' ? 'dark' : 'light'} theme.`">
            <i v-if="theme == 'dark'" class="mdi mdi-weather-sunny"></i>
            <i v-if="theme == 'light'" class="mdi mdi-weather-night"></i>
          </button>
        </div>
        <Login />

        <p role="button" class="btn btn-outline-success btn-sm mdi mdi-cart mb-0 d-lg-none" type="button"
          data-bs-toggle="offcanvas" data-bs-target="#offcanvasResponsive"
          aria-controls="offcanvasResponsive"></p>


        <div class="offcanvas-lg offcanvas-end" tabindex="-1" id="offcanvasResponsive"
          aria-labelledby="offcanvasResponsiveLabel">
          <div class="offcanvas-header">
            <h5 class="offcanvas-title" id="offcanvasResponsiveLabel">Cart</h5>
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas"
              data-bs-target="#offcanvasResponsive" aria-label="Close"></button>
          </div>
          <div class="offcanvas-body">
            <p class="mb-0 text-dark shadow-sm p-3 mb-5 bg-body-tertiary rounded ">{{
              AppState.sodasInCart.length }} Sodas in Cart</p>

          </div>
        </div>
      </div>
    </div>
  </nav>
</template>

<style lang="scss" scoped>
a {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
