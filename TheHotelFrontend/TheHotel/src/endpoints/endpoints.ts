
export const baseURL = 'https://localhost:7114/api/'

export const roomServiceMenuEndpoint = `RoomService/menu`
export const placeOrderEndpoint = `RoomServiceOrder`
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

export function getOrdersEndpoint(userId:string) {
    return `RoomServiceOrder/user/${userId}`
} 

//Authentication

export const loginEndpoint = `auth/login`
export const registerEndpoint = `auth/register`