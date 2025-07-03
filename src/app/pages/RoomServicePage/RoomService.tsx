
import * as React from 'react';
import Box from '@mui/material/Box';
import BottomNavigation from '@mui/material/BottomNavigation';
import BottomNavigationAction from '@mui/material/BottomNavigationAction';
import RestoreIcon from '@mui/icons-material/Restore';
import FavoriteIcon from '@mui/icons-material/Favorite';
import LocationOnIcon from '@mui/icons-material/LocationOn';
import { useState } from 'react';
import { Height } from '@mui/icons-material';
export default function RoomService(){
    const [value, setValue] = useState(0);

    return(

        <div  className='main-holder'>
            <div>
                This is room service options
            </div>



            <div>
                
            </div>
        </div>



            
    )
}