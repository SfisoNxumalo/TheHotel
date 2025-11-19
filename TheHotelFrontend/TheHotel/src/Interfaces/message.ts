export interface Attachment {
  type: "image" | "file" | "video" | "audio";
  url: string;
  fileName?: string;
}

export interface Message {
  id: number;
  userId: string;
  staffId: string;
  messageText: string;
  senderId:string;
  createdDate: string;
}