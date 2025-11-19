import { Fab, IconButton, styled, TextareaAutosize } from '@mui/material';
import styles from './AdminChatInput.module.css'
import { BsSend } from "react-icons/bs";
import { ImAttachment } from "react-icons/im";
import { useState } from 'react';
import { sendMessage } from '../../../../../services/messageService';
import { Message } from '../../../../../Interfaces/message';
import { SendNewMessage } from '../../../../../Interfaces/sendMessage';
import { useAuthStore } from '../../../../../stores/authStore';
import { useMessageStore } from '../../../../../stores/messageStore';


const VisuallyHiddenInput = styled('input')({
  clip: 'rect(0 0 0 0)',
  clipPath: 'inset(50%)',
  height: 1,
  overflow: 'hidden',
  position: 'absolute',
  bottom: 0,
  left: 0,
  whiteSpace: 'nowrap',
  width: 1,
});

interface chatInputProps{
    setMessage: (message:Message[]) => void,
    setIsSending:(sending:boolean) => void
    messages:Message[]
}

export default function AdminChatInput({setMessage, setIsSending, messages}:chatInputProps){

    const [typedMessage, setTypedMessage] = useState("");
    const user = useAuthStore((s) => s.user);

    const addMessage = useMessageStore(s => s.addMessage);

    const handleSendMessage = async () => {
        if (!typedMessage.trim()) return;

        const newMessage:SendNewMessage = {
            messageText:typedMessage,
            userId: `03753F20-B814-4D3E-AC83-08DE26F78854`,
            staffId:'57FD88E1-4BD2-44BD-B33E-301232D0983C',
            senderId: `57FD88E1-4BD2-44BD-B33E-301232D0983C`
        }

        setIsSending(true)
        
        const response = await sendMessage(newMessage)
        
        if(response.status == 201){
            
            addMessage(response.data)
        }

        setIsSending(false)
    }

    return(
            <div className={styles.holder}>
                <IconButton sx={{fontSize:18}} aria-label="delete" component="label"
                    role={undefined}
                    tabIndex={-1} >
                        <ImAttachment />
                        <VisuallyHiddenInput
                        // className={styles.MediaButton}
                            type="file"
                            onChange={(event) => console.log(event.target.files)}
                            multiple
                        />
                </IconButton>
                
                <div className={styles.inputs}>
                <TextareaAutosize className={styles.TextareaAutosize}
                    maxRows={3}
                    aria-label="maximum height"
                    placeholder="Message"
                    defaultValue=""
                     onChange={(event)=> {
                        setTypedMessage(event.target.value);
                    }}
                    style={{ width: 200 }}
                    />
                    <Fab onClick={handleSendMessage} size="small" color="primary" aria-label="add">
                        <BsSend />
                    </Fab>
                </div>
                
            </div>
    );
}