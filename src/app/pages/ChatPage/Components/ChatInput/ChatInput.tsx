import { Fab, IconButton, styled, TextareaAutosize } from '@mui/material';
import styles from './ChatInput.module.css'
import { BsSend } from "react-icons/bs";
import { ImAttachment } from "react-icons/im";

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


export default function ChatInput(){
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
                    style={{ width: 200 }}
                    />
                    <Fab size="small" color="primary" aria-label="add">
                        <BsSend />
                    </Fab>
                </div>
                
            </div>
    );
}