import { Person } from "@mui/icons-material";
import { Badge, BadgeProps, BottomNavigation, BottomNavigationAction, styled } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { IoCartOutline, IoChatboxEllipsesOutline, IoFastFoodOutline, IoHomeOutline } from "react-icons/io5";


  const StyledBadge = styled(Badge)<BadgeProps>(({ theme }) => ({
    '& .MuiBadge-badge': {
      right: 0,
      top: 0,
      border: `2px solid transparent`,
      padding: '0 4px',
    },
  }));

  
export default function BottomNav(){

  const navigate = useNavigate();
    const [value, setValue] = useState('/dashboard');

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
    // if(window.location.pathname){
    //   setValue(window.location.pathname)
    // }
  };

  return (
    window.location.pathname  == '/chats' ? <></> :
    <BottomNavigation style={{boxShadow:'rgba(50, 50, 93, 0.25) 0px 2px 5px -1px, rgba(0, 0, 0, 0.3) 0px 1px 3px -1px'}} sx={{ position: 'fixed',fontSize:"10px", bottom: 0, left: 0, right: 0 , zIndex:1000}} value={value} onChange={handleChange}>
      <BottomNavigationAction 
        // label="Dashboard"
        sx={{fill:"green"}}
        value="Dashboard"
        onClick={()=>navigate("/dashboard")}
        icon={<IoHomeOutline  fontSize={20}/>}
      />
      <BottomNavigationAction
        // label="Room Service"
        value="Room Service"
        onClick={()=>navigate("/room-service")}
        icon={<IoFastFoodOutline fontSize={20}/>}
      />
      <BottomNavigationAction
        // label="Chat"
        value="Chat"
        onClick={()=>navigate("/chats")}
        icon={
          <StyledBadge badgeContent={1} color="secondary">
            <IoChatboxEllipsesOutline   fontSize={20}/>
          </StyledBadge>
        }
      />
      <BottomNavigationAction
        // label="Cart"
        value="Cart"
        onClick={()=>navigate("/Cart")}
        icon={
          <StyledBadge badgeContent={1} color="secondary">
            <IoCartOutline fontSize={20}/>
          </StyledBadge>
        }
        
      />
      <BottomNavigationAction
        // label="Account"
        value="Account"
        onClick={()=>navigate("/profile")}
        icon={<Person fontSize="small"  />}
      />
      
    </BottomNavigation>
  );
}
