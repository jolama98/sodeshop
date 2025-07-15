export class Soda {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.price = data.price
        this.description = data.description
        this.creator = data.creator
        this.imageUrl = data.image_url || 'https://plus.unsplash.com/premium_photo-1725075086631-b21a5642918b?q=80&w=2787&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D'
    }
}