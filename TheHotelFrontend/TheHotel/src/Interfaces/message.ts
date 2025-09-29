export interface Attachment {
  type: "image" | "file" | "video" | "audio";
  url: string;
  fileName?: string;
}

export interface Message {
  id: number;
  conversationId: string;
  guid: string; // user ID
  name: string;
  message: string;
  type: "sent" | "received";
  date: string;
  status: "sent" | "delivered" | "read" | "failed" | "typing";
  attachments: Attachment[];
  isTyping?: boolean;
}