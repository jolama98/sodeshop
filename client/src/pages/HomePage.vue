<script setup>
import { AppState } from '@/AppState';
import SodaCard from '@/components/SodaCard.vue';
import { sodaService } from '@/services/SodaService';
import { Pop } from '@/utils/Pop';
import { computed, onMounted } from 'vue';

const sodas = computed(() => AppState.sodas);
onMounted(() => {
  getAllSodas();
  console.log('HomePage component mounted');
});
async function getAllSodas() {
  try {
    await sodaService.getSodas()
  }
  catch (error) {
    Pop.error(error);
  }

}


</script>

<template>
  <div class="container-fluid mt-3">
    <div class="row">
      <div class="col-12">
        <div class="masonry-layout">

          <div v-for="soda in sodas" :key="soda.id" class="masonry-item">
            <SodaCard :sodaProps="soda" />
          </div>
        </div>
      </div>
    </div>
  </div>


</template>

<style scoped lang="scss">
.masonry-layout {
  column-count: 4;
  column-gap: 1rem;
  width: 100%;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1rem;
}

@media (max-width: 768px) {
  .masonry-layout {
    column-count: 3;
  }
}

@media (max-width: 550px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>
