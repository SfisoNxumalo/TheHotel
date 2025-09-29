
import { Message } from '../../../../../Interfaces/message';
import styles from './RightChatItem.module.css'


interface RightChatItemProps {
  message: Message;
}

export default function RightChatItem({message}:RightChatItemProps){
 
    return(
        <div className={styles.holder}>
            <div className={styles.MessageHolder}>
                <p>
                    {message.message}
                </p>
                <div className={styles.metaData}>
                    <label>{(String(message.date).substring(11, 16)) }</label>
                    <label>&#x2713;</label>
                </div>
                
            </div>
        </div>
    )
}