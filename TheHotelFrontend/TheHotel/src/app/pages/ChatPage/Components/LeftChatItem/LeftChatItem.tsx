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
                    {message.message}
                </p>
                <div className={styles.metaData}>
                    <label>{(String(message.date).substring(11, 16)) }</label>
                </div>
                
            </div>
        </div>
    )
}