<script setup>
import { sodaService } from '@/services/SodaService';
import { Pop } from '@/utils/Pop';
import { onMounted } from 'vue';


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
  <h1>Hello</h1>
</template>

<style scoped lang="scss"></style>
