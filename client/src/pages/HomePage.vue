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
  <div v-for="soda in sodas" :key="soda.id">
    <SodaCard :sodaProps="soda" />
  </div>
</template>

<style scoped lang="scss"></style>
