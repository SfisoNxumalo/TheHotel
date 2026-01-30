
import { Message } from '../../../../../Interfaces/message';
import styles from './AdminRightChatItem.module.css'


interface RightChatItemProps {
  message: Message;
}

export default function AdminRightChatItem({message}:RightChatItemProps){
 
    return(
        <div className={styles.holder}>
            <div className={styles.MessageHolder}>
                <p>
                    {message.messageText}
                </p>
                <div className={styles.metaData}>
                    <label>{(String(message.createdDate).substring(11, 16)) }</label>
                    <label>&#x2713;</label>
                </div>
                
            </div>
        </div>
    )
}