<script setup>
import { AppState } from '@/AppState';
import { Soda } from '@/models/Soda';
import { computed } from 'vue';

const props = defineProps({
    sodaProps: { type: Soda, required: true }
});
// const account = computed(() => AppState.account);


</script>


<template>
    <div v-if="sodaProps" class="card">
        <div class="d-flex justify-content-center align-items-center p-2">
            {{ props.sodaProps.name }}
        </div>

        <img :src="props.sodaProps?.imageUrl" class="card-img-top img-fluid d-flex flex-column justify-content-between"
            alt="Soda Image">

        <!-- <i v-if="account?.id == keepProps.creator.id" type="button" @click="deleteKeep(keepProps.id)"
        class="delete-button mdi mdi-close-octagon-outline fs-1 text-danger d-flex icon-pos">
        <svg class="delete-svgIcon" viewBox="0 0 448 512">
          <path
            d="M135.2 17.7L128 32H32C14.3 32 0 46.3 0 64S14.3 96 32 96H416c17.7 0 32-14.3 32-32s-14.3-32-32-32H320l-7.2-14.3C307.4 6.8 296.3 0 284.2 0H163.8c-12.1 0-23.2 6.8-28.6 17.7zM416 128H32L53.2 467c1.6 25.3 22.6 45 47.9 45H346.9c25.3 0 46.3-19.7 47.9-45L416 128z">
          </path>
        </svg>
      </i> -->

        <div class="card-body d-flex flex-column justify-content-end pb-0">
            <h5 class="textShadow">
            </h5>
            <div class="d-flex flex-row justify-content-between">
                <p class="p-1">{{ props.sodaProps.creator.name }}</p>
                <img role="button" :src=props.sodaProps.creator.picture class="avatar" alt="">
            </div>
            <p class="card-text">$ {{ props.sodaProps.price }}.</p>

            <p>{{ props.sodaProps.description }}</p>

            <button class="btn btn-warning border rounded-4 mb-2">Add To card</button>
        </div>
    </div>
</template>


<style lang="scss" scoped>
.textShadow {
    text-shadow: 1px 1px 1px rgb(0, 0, 0);
    font-family: 'Courier New', Courier, monospace;
}

.avatar {
    vertical-align: middle;
    width: 4dvh;
    height: 4dvh;
    border-radius: 50%;
}
</style>