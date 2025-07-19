import { Soda } from "@/models/Soda.js";
import { api } from "./AxiosService.js";
import { AppState } from "@/AppState.js";
import { logger } from "@/utils/Logger.js";

class SodaService {

    async getSodas() {
        const response = await api.get('api/soda')
        const newSodas = response.data.map(sodaData => new Soda(sodaData))
        logger.log(response.data)
        AppState.sodas = newSodas
    }

    async getSodaById(sodaId) {
        AppState.activeSoda = null
        const response = await api.get(`api/soda/${sodaId}`)
        const sodaData = response.data
        logger.log(sodaData)
        AppState.activeSoda = response.data
    }
}

export const sodaService = new SodaService();