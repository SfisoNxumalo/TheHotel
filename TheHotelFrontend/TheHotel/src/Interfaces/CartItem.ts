export interface CartItem {
  id: string;
  itemName: string;
  price: number;
  image: string;
  quantity: number;
  note:string;
}

export interface Checkout{
  userId:string,
  items:CartItem[]
}