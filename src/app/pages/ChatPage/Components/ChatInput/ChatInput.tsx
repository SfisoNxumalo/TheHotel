import { Fab, TextareaAutosize } from '@mui/material';
import styles from './ChatInput.module.css'
import { Send } from '@mui/icons-material';
import { BsSend } from "react-icons/bs";
import { FiSend } from "react-icons/fi";
import { ImAttachment } from "react-icons/im";
export default function ChatInput(){
    return(
            <div className={styles.holder}>
                <button  className={styles.MediaButton}><ImAttachment /></button>
                <div className={styles.inputs}>
                <TextareaAutosize className={styles.TextareaAutosize}
                    maxRows={3}
                    aria-label="maximum height"
                    placeholder="Message"
                    defaultValue=""
                    style={{ width: 200 }}
                    />
                    <Fab size="small" color="primary" aria-label="add">
                        <BsSend />
                    </Fab>
                </div>
                
            </div>
    );
}