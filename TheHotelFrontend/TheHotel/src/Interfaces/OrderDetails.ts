export interface OrderDetails {
orderId: string,
userId: string,
userName:string,
userContact:string,
items: OrderItems[],
note: null,
createdAt: string,
status: string
}

interface OrderItems{
id: string,
itemName: string,
price: number,
quantity: number,
note: string
}