import { Typography, AppBar, Container, CssBaseline, Toolbar, useScrollTrigger, List, TextareaAutosize, Avatar, ListItemAvatar } from "@mui/material";
import React, { useEffect, useRef, useState } from "react";
import AdminLeftChatItem from "./Components/AdminLeftChatItem/AdminLeftChatItem";
import AdminRightChatItem from "./Components/AdminRightChatItem/AdminRightChatItem";
import styles from './AdminChatPageStyle.module.css'
import AdminChatInput from "./Components/AdminChatInput/AdminChatInput";
import { useNavigate } from "react-router-dom";
import { Message } from "../../../Interfaces/message";
import { getAllMessages, useFetchMessages } from "../../../services/messageService";
import { GoArrowLeft } from "react-icons/go";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import { useMessageStore } from "../../../stores/messageStore";
import { useAuthStore } from "../../../stores/authStore";
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

export default function AdminChats(props: Props){
   const [isSending, setIsSending] = useState<boolean>(false);
    const [allMessages, setAllMessage] = useState<Message[]>([]);
    const navigate = useNavigate();

const bottomRef = useRef<null | HTMLDivElement>(null);

  const scrollToBottom = () => {
    bottomRef.current?.scrollIntoView();
  };

  // const { messages, loading, error } = useMessageStore();
  const setMessages = useMessageStore((state) => state.setMessages);
  const user = '57FD88E1-4BD2-44BD-B33E-301232D0983C'
  const {data, isSuccess} = useFetchMessages(`${user}`)
  
  useEffect(()=>{
    if(isSuccess){
      setMessages(data);
    }
  },[data]);

  useEffect(()=>{
  scrollToBottom();
  },[])

   const messages = useMessageStore((state) => state.messages);

    return (
      <div className={styles.hold}>
        <React.Fragment>
              <CssBaseline />
              <ElevationScroll {...props}>
                  <AppBar>
                  <Toolbar style={{display:'flex', gap:'10px', paddingLeft: '5px'}}>
                    <ListItemAvatar style={{display:'flex'}}>
                      <button className={globalStyles.backButton} onClick={()=>navigate(-1)}><GoArrowLeft /></button>
                        <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
                    </ListItemAvatar>
                    <Typography variant="h6" component="div">
                    Ben
                    </Typography>
                  </Toolbar>
                  </AppBar>
              </ElevationScroll>
              <Toolbar />
              <Container style={{padding:"10px"}} >
                  <List sx={{ width: '100%', bgcolor: 'background.paper', gap:"10px", display:"flex", flexDirection:"column"  }}>
                      { messages.map((message, index) => 
                                <div key={message.id}> {message.senderId.toLowerCase() == user.toLowerCase() ? 
                                  <AdminRightChatItem  message={message} /> : 
                                  <AdminLeftChatItem  message={message} />}
                                </div>  
                          )}
                  </List>
              <div style={{height:"65px"}} ref={bottomRef} />
              </Container>
        </React.Fragment>
        <AdminChatInput setMessage={setAllMessage} messages={allMessages} setIsSending={setIsSending}/>
      </div> 
    );
}