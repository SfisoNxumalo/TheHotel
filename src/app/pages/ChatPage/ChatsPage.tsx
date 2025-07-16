import { Typography, AppBar, Container, CssBaseline, Toolbar, useScrollTrigger, List, TextareaAutosize } from "@mui/material";
import React, { useEffect, useRef } from "react";
import LeftChatItem from "./Components/LeftChatItem/LeftChatItem";
import RightChatItem from "./Components/RightChatItem/RightChatItem";

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
const arr = [1,2,2,5,6,5,656,6,56,5,4,4,4,4,54,564,4,];


const bottomRef = useRef<null | HTMLDivElement>(null);

  const scrollToBottom = () => {
    bottomRef.current?.scrollIntoView();
  };

  
useEffect(()=>{
  scrollToBottom();
  console.log("yess");
  
},[])

    return (
        <React.Fragment>
            <CssBaseline />
            <ElevationScroll {...props}>
                <AppBar>
                <Toolbar>
                    <Typography variant="h6" component="div">
                    Scroll to elevate App bar
                    </Typography>
                </Toolbar>
                </AppBar>
            </ElevationScroll>
            <Toolbar />
            <Container  >
                <List sx={{ width: '100%', bgcolor: 'background.paper', gap:"10px", display:"flex", flexDirection:"column"  }}>
                    { arr.map((index) => 
                              <><LeftChatItem /><RightChatItem /></>
                        )}
                        <div>
                          <TextareaAutosize
                              maxRows={4}
                              aria-label="maximum height"
                              placeholder="Maximum 4 rows"
                              defaultValue="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt
                                  ut labore et dolore magna aliqua."
                              style={{ width: 200 }}
/>
                        </div>
                </List>
            <div ref={bottomRef} />
            </Container>
    </React.Fragment>
    );
}