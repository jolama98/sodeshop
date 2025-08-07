import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";

class CartService {
    async getSodasInCart(cartId) {
        const response = await api.get(`api/cart/${cartId}/sodas`);
        logger.log(response.data);
        AppState.sodasInCart = response.data;
    }

}
export const cartService = new CartService();