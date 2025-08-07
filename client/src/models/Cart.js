export class Cart {
    constructor(data) {
        this.id = data.id
        this.userId = data.userId
        this.sodas = data.sodas || []
        this.totalPrice = data.totalPrice || 0
        this.createdAt = data.createdAt || new Date()
    }
}