
import { Badge, BadgeProps, BottomNavigation, BottomNavigationAction, styled } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { IoChatboxEllipsesOutline, IoHomeOutline } from "react-icons/io5";
import { useMessageStore } from "../../stores/messageStore";
import { GrAnalytics } from "react-icons/gr";


  const StyledBadge = styled(Badge)<BadgeProps>(() => ({
    '& .MuiBadge-badge': {
      right: 0,
      top: 0,
      border: `2px solid transparent`,
      padding: '0 4px',
    },
  }));

  
export default function AdminBottomNav(){

  const navigate = useNavigate();
    const [value, setValue] = useState('/admin/dashboard');

    const newMessageCount = useMessageStore((s) => s.newMessageCount);

  const handleChange = (_event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };

  return (
    window.location.pathname  == '/admin/chats' ? <></> :
    <BottomNavigation style={{boxShadow:'rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px'}} sx={{ position: 'fixed',fontSize:"10px", bottom: 0, left: 0, right: 0 , zIndex:1000}} value={value} onChange={handleChange}>
      <BottomNavigationAction 
        // label="Dashboard"
        sx={{fill:"green"}}
        value="Dashboard"
        onClick={()=>navigate("/admin/dashboard")}
        icon={<IoHomeOutline  fontSize={20}/>}
      />
      <BottomNavigationAction
        // label="Room Service"
        value="analytics"
        onClick={()=>navigate("/admin/analytics")}
        icon={<GrAnalytics fontSize={20}/>}
      />
      <BottomNavigationAction
        // label="Chat"
        value="Chat"
        onClick={()=>navigate("/admin/chats")}
        icon={
          <StyledBadge badgeContent={newMessageCount} color="secondary">
            <IoChatboxEllipsesOutline   fontSize={20}/>
          </StyledBadge>
        }
      />
    </BottomNavigation>
  );
}
