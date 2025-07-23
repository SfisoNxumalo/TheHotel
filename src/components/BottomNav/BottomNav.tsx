import { Restore, Favorite, LocationOn, Folder, Home, DinnerDining, Person, Chat } from "@mui/icons-material";
import ShoppingCart from "@mui/icons-material/ShoppingCart";
import { Badge, BadgeProps, BottomNavigation, BottomNavigationAction, IconButton, styled } from "@mui/material";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";


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
    window.location.pathname  == '/Chats' ? <></> :
    <BottomNavigation sx={{ position: 'fixed',fontSize:"10px", bottom: 0, left: 0, right: 0 , zIndex:1000}} value={value} onChange={handleChange}>
      <BottomNavigationAction
        // label="Dashboard"
        sx={{fill:"green"}}
        value="Dashboard"
        onClick={()=>navigate("/dashboard")}
        icon={<Home  fontSize="small"  />}
      />
      <BottomNavigationAction
        // label="Room Service"
        value="Room Service"
        onClick={()=>navigate("/room-service")}
        icon={<DinnerDining  fontSize="small" />}
      />
      <BottomNavigationAction
        // label="Chat"
        value="Chat"
        onClick={()=>navigate("/chats")}
        icon={<IconButton  aria-label="cart">
                                    <StyledBadge badgeContent={1} sx={{color:'grey'}}color="secondary">
                                      <Chat sx={{ fontSize: 20 }} />
                                    </StyledBadge>
                                  </IconButton>}
      />
      <BottomNavigationAction
        // label="Cart"
        value="Cart"
        onClick={()=>navigate("/Cart")}
        icon={<IconButton  aria-label="cart">
                                    <StyledBadge badgeContent={1} sx={{color:'grey'}}color="secondary">
                                      <ShoppingCart sx={{ fontSize: 20 }} />
                                    </StyledBadge>
                                  </IconButton>}
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
