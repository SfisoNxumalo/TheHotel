import { Fab, TextareaAutosize } from '@mui/material';
import styles from './ChatInput.module.css'
import { Send } from '@mui/icons-material';

export default function ChatInput(){
    return(
            <div className={styles.holder}>
                <button  className={styles.MediaButton}>+</button>
                <div className={styles.inputs}>
                <TextareaAutosize className={styles.TextareaAutosize}
                    maxRows={3}
                    aria-label="maximum height"
                    placeholder="Message"
                    defaultValue="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
                        ut labore et dolore magna aliqua."
                    style={{ width: 200 }}
                    />
                    <Fab size="small" color="primary" aria-label="add">

                    </Fab>
                </div>
                
            </div>
    );
}