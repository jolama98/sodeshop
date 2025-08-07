<script setup>
import { AppState } from '@/AppState';
import { Soda } from '@/models/Soda';
import { cartService } from '@/services/CartIService';
import { sodaService } from '@/services/SodaService';
import { logger } from '@/utils/Logger';
import { Pop } from '@/utils/Pop';
import { computed, ref } from 'vue';


const activeSoda = computed(() => AppState.sodaById)
const props = defineProps({
    sodaProps: { type: Soda, required: true }
});
// const account = computed(() => AppState.account);
const savedSodaToCartData = ref({
    sodaId: 0,
    cartId: 0,
})

async function AddToCart() {
    try {
        savedSodaToCartData.value.sodaId = activeSoda.value.id;
        await cartService.getSodasInCart(savedSodaToCartData.value)

        logger.log(AppState.sodaById.id)
        logger.log(AppState.sodasInCart.length)

        savedSodaToCartData.value = {
            sodaId: 0,
            cartId: 0,
        }
    }
    catch (error) {
        Pop.error(error);
    }
}

//FIXME - Fix the error in the browser
async function setActiveSoda(sodaId) {
    try {
        await sodaService.getSodaById(sodaId);
        Pop.success('Soda added to cart');
    }
    catch (error) {
        Pop.error(error);
    }

}


</script>


<template>
    <div col v-if="sodaProps" class="card">
        <div class="d-flex justify-content-center align-items-center p-2">
            {{ props.sodaProps.name }}
        </div>

        <img :src="props.sodaProps?.imageUrl"
            class="card-img-top img-fluid d-flex flex-column justify-content-between" alt="Soda Image">


        <div class="card-body d-flex flex-column justify-content-end pb-0" data-bs-toggle="modal"
            data-bs-target="#cartModal">
            <h5 class="textShadow">
            </h5>
            <div class="d-flex flex-row justify-content-between">
                <p class="p-1">{{ props.sodaProps.creator.name }}</p>
                <img role="button" :src=props.sodaProps.creator.picture class="avatar" alt="">
            </div>
            <p class="card-text">$ {{ props.sodaProps.price }}.</p>

            <p>{{ props.sodaProps.description }}</p>

            <button @click="setActiveSoda(props.sodaProps.id)"
                class="btn btn-warning border rounded-4 mb-2">Add To card</button>
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