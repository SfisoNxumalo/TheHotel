import { Typography, AppBar, Container, CssBaseline, Toolbar, useScrollTrigger, List, TextareaAutosize, Avatar, ListItemAvatar } from "@mui/material";
import React, { useEffect, useRef, useState } from "react";
import LeftChatItem from "./Components/LeftChatItem/LeftChatItem";
import RightChatItem from "./Components/RightChatItem/RightChatItem";
import styles from './ChatPageStyle.module.css'
import ChatInput from "./Components/ChatInput/ChatInput";
import { useNavigate } from "react-router-dom";
import { Message } from "../../../Interfaces/message";
import { getAllMessages, useFetchMessages } from "../../../services/messageService";
import { GoArrowLeft } from "react-icons/go";
import globalStyles from '../../../GlobalStyles/globalStyle.module.css'
import { useMessageStore } from "../../../stores/messageStore";
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

const loggedInUser = '3C9C5A01-41A2-43D5-99E8-10B7CFD508F1';

   const [isSending, setIsSending] = useState<boolean>(false);
  const [allMessages, setAllMessage] = useState<Message[]>([]);
    const navigate = useNavigate();

const bottomRef = useRef<null | HTMLDivElement>(null);

  const scrollToBottom = () => {
    bottomRef.current?.scrollIntoView();
  };

  // const { messages, loading, error } = useMessageStore();
  const setMessages = useMessageStore((state) => state.setMessages);

  const {data, isSuccess} = useFetchMessages(loggedInUser)
  
  useEffect(()=>{
    if(isSuccess){
      setMessages(data);
      console.log(data);
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
                    Assistant manager
                    </Typography>
                  </Toolbar>
                  </AppBar>
              </ElevationScroll>
              <Toolbar />
              <Container style={{padding:"10px"}} >
                  <List sx={{ width: '100%', bgcolor: 'background.paper', gap:"10px", display:"flex", flexDirection:"column"  }}>
                      { messages.map((message, index) => 
                                <div key={message.id}> {message.userId.toLowerCase() == loggedInUser.toLowerCase() ? 
                                  <RightChatItem  message={message} /> : 
                                  <LeftChatItem  message={message} />}
                                </div>  
                          )}
                          
                  </List>
              <div style={{height:"65px"}} ref={bottomRef} />
              </Container>
              
        </React.Fragment>
        <ChatInput setMessage={setAllMessage} messages={allMessages} setIsSending={setIsSending}/>
      </div> 
    );
}