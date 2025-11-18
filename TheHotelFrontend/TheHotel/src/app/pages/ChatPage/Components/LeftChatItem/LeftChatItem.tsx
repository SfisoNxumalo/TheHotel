
import { Message } from '../../../../../Interfaces/message';
import styles from './LeftItemChat.module.css'


interface LeftChatItemProps {
  message: Message;
}

export default function LeftChatItem({message}:LeftChatItemProps){

    return(
        <div className={styles.holder}>
            <div className={styles.MessageHolder}>
                <p>
                    {message.messageText}
                </p>
                <div className={styles.metaData}>
                    <label>{(String(message.createdDate).substring(11, 16)) }</label>
                </div>
                
            </div>
        </div>
    )
}