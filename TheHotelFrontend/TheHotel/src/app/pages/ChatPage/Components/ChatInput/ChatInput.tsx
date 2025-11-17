import { Fab, IconButton, styled, TextareaAutosize } from '@mui/material';
import styles from './ChatInput.module.css'
import { BsSend } from "react-icons/bs";
import { ImAttachment } from "react-icons/im";
import { useState } from 'react';
import { sendMessage } from '../../../../../services/messageService';
import { Message } from '../../../../../Interfaces/message';
import { SendNewMessage } from '../../../../../Interfaces/SendMessage';

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

export default function ChatInput({setMessage, setIsSending, messages}:chatInputProps){

    const [typedMessage, setTypedMessage] = useState("");

    const handleSendMessage = async () => {
        if (!typedMessage.trim()) return;

        const newMessage:SendNewMessage = {
            messageText:typedMessage,
            userId:'3C9C5A01-41A2-43D5-99E8-10B7CFD508F1',
            staffId:'CF509E5B-D40F-4766-B07D-5046445C63D4'
        }

        setIsSending(true)
        
        const response = await sendMessage(newMessage)

        if(response.status == 201){
            console.log("Send Successfully");
            messages.push(response.data)
            console.log(messages);
            
            setMessage(messages)
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