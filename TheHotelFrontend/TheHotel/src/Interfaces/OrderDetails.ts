export interface OrderDetails {
orderId: string,
userId: string,
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