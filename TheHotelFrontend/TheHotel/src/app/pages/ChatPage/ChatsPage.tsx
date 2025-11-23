import { Typography, AppBar, Container, CssBaseline, Toolbar, useScrollTrigger, List, TextareaAutosize, Avatar, ListItemAvatar } from "@mui/material";
import React, { useEffect, useRef, useState } from "react";
import LeftChatItem from "./Components/LeftChatItem/LeftChatItem";
import RightChatItem from "./Components/RightChatItem/RightChatItem";
import styles from './ChatPageStyle.module.css'
import ChatInput from "./Components/ChatInput/ChatInput";
import { useNavigate } from "react-router-dom";
import { Message } from "../../../Interfaces/message";
import { getAllMessages, getStaffDetails, getUserDetails, useFetchMessages } from "../../../services/messageService";
import { GoArrowLeft } from "react-icons/go";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import { useMessageStore } from "../../../stores/messageStore";
import { useAuthStore } from "../../../stores/authStore";
import AdminChatInput from "../AdminChat/Components/AdminChatInput/AdminChatInput";
import { AuthUser } from "../../../Interfaces/AuthUser";
interface Props {
  /**
   * Injected by the documentation to work in an iframe.
   * You won't need it on your project.
   */
  window?: () => Window;
  children?: React.ReactElement<{ elevation?: number }>;
}


function ElevationScroll(props: Props) {
  const { children, window } = props;
  // Note that you normally won't need to set the window ref as useScrollTrigger
  // will default to window.
  // This is only being set here because the demo is in an iframe.
  const trigger = useScrollTrigger({
    disableHysteresis: true,
    threshold: 0,
    target: window ? window() : undefined,
  });

  return children
    ? React.cloneElement(children, {
        elevation: trigger ? 3 : 0,
      })
    : null;
}

export default function Chats(props: Props){
   const [isSending, setIsSending] = useState<boolean>(false);
    const [allMessages, setAllMessage] = useState<Message[]>([]);
    const navigate = useNavigate();

    const [receiver, setReceiver] = useState<AuthUser>();

const bottomRef = useRef<null | HTMLDivElement>(null);

  const scrollToBottom = () => {
    bottomRef.current?.scrollIntoView();
  };

  // const { messages, loading, error } = useMessageStore();
  const setMessages = useMessageStore((state) => state.setMessages);
  const resetNewMessagecount = useMessageStore((state) => state.resetNewMessageCount);
  const user = useAuthStore((s) => s.user);
  const {data, isSuccess} = useFetchMessages(`${user?.id}`)
  
  useEffect(()=>{
    if(isSuccess){
      setMessages(data);
      resetNewMessagecount()
    }
  },[data]);

   useEffect(()=>{
    const getReceiver = async() =>{
      const res = await getStaffDetails();

      if(res.status === 200){
        setReceiver(res.data)
      }
    }

    getReceiver()
  },[data]);

  useEffect(()=>{
  scrollToBottom();
  },[])

   const messages = useMessageStore((state) => state.messages).filter(
    (msg, index, self) => index === self.findIndex(m => m.id === msg.id)
);

    return (
      <div className={styles.hold}>
        <React.Fragment>
              <CssBaseline />
              <ElevationScroll {...props}>
                  <AppBar>
                  <Toolbar style={{display:'flex', gap:'10px', paddingLeft: '5px'}}>
                    <ListItemAvatar style={{display:'flex'}}>
                      <button className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
                        <Avatar alt={`${receiver?.fullName.toUpperCase()}`} src="/static/images/avatar/1.jpg" />
                    </ListItemAvatar>
                    <Typography variant="h6" component="div">
                    {receiver?.fullName}
                    </Typography>
                  </Toolbar>
                  </AppBar>
              </ElevationScroll>
              <Toolbar />
              <Container style={{padding:"10px"}} >
                  <List sx={{ width: '100%', bgcolor: 'background.paper', gap:"10px", display:"flex", flexDirection:"column"  }}>
                      { messages.map((message, index) => 
                                <div key={message.id}> {message.senderId.toLowerCase() == user?.id.toLowerCase() ? 
                                  <RightChatItem  message={message} /> : 
                                  <LeftChatItem  message={message} />}
                                </div>  
                          )}
                          
                  </List>
              <div style={{height:"65px"}} ref={bottomRef} />
              </Container>
              
        </React.Fragment>
        { receiver?.id && <ChatInput receiver={receiver} setIsSending={setIsSending}/>}
      </div> 
    );
}