import { create } from 'zustand';
import { Message } from '../Interfaces/message';


interface MessageState {
  messages: Message[];
  loading: boolean;
  error: string | null;

  setMessages: (messages: Message[]) => void;
  addMessage: (message: Message) => void;
  clearMessages: () => void;
  newMessageCount: number;
incrementNewMessageCount: () => void;
resetNewMessageCount: () => void;

//   fetchMessages: (userId: string) => Promise<void>;
}

export const useMessageStore = create<MessageState>()(
  
    (set, get) => ({
        newMessageCount: 0,
      messages: [],
      loading: false,
      error: null,

      setMessages: (messages) => set({ messages }),

      addMessage: (message) =>
        set((state) => ({
          messages: [...state.messages, message],
          newMessageCount: state.newMessageCount + 1,
        })),

      clearMessages: () => set({ messages: [] }),
      incrementNewMessageCount: () =>
    set((state) => ({
      newMessageCount: state.newMessageCount + 1,
    })),

    resetNewMessageCount: () => set({ newMessageCount: 0 }),

    //   fetchMessages: async (userId: string) => {
    //     set({ loading: true, error: null });
    //     try {
    //       const res = await fetch(
    //         `https://your-api-url.com/api/messages/${userId}`
    //       );

    //       if (!res.ok) {
    //         throw new Error(`Failed to fetch messages (${res.status})`);
    //       }

    //       const data: Message[] = await res.json();
    //       set({ messages: data });
    //     } catch (err: any) {
    //       set({ error: err.message || 'Error fetching messages' });
    //     } finally {
    //       set({ loading: false });
    //     }
    //   },
    })
);
