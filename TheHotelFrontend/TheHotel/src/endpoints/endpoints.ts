
export const baseURL = 'https://localhost:7114/api/'

export const RoomServiceMenuEndpoint = `RoomService/menu`
export const PlaceOrderEndpoint = `RoomServiceOrder`
export const messageEndpoint = `Message`

export function getMenuItemByIdEndpoint(menuitemId:string){
    return `RoomService/menu/${menuitemId}`;
}

export function getMessageEndpoint(userId:string) {
    return `Message/${userId}`
} 

export function getOrderDetailsEndpoint(orderId:string) {
    return `RoomServiceOrder/${orderId}`
} 