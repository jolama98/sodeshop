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
    <div v-if="sodaProps">
        <p>{{ props.sodaProps.name }}</p>
        <p>{{ props.sodaProps.price }}</p>
        <p>{{ props.sodaProps.description }}</p>
        <img :src="props.sodaProps.image" alt="Soda Image" />
        <!-- Add more soda details as needed -->
    </div>
</template>


<style lang="scss" scoped></style>