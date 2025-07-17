
import { List, ListSubheader, ListItem, ListItemText, Autocomplete, Stack, TextField, BottomNavigation, BottomNavigationAction, Badge, IconButton } from '@mui/material';
import { useState } from 'react';
import ListHolder from './Components/ListHolder/ListHolder';
import SearchBar from './Components/SearchBar/SearchBar';
import { FavoriteOutlined, Folder, Home, LocalAirport, Person, Person2, Person3, PersonOffOutlined, Restore, Shop, ShoppingCart } from '@mui/icons-material';
export default function RoomService(){
    const [value, setValue] = useState(0);

    const [values, setValues] = useState('recents');

  const handleChange = (event: React.SyntheticEvent, newValue: string) => {
    setValue(newValue);
  };
    
    return(
        <>
        <SearchBar/>
        
        <ListHolder/>
    <IconButton>
  <ShoppingCart fontSize="small" />
  <Badge badgeContent={2} color="primary" overlap="circular" />
</IconButton>
        <BottomNavigation sx={{ width: 500 }} value={value} onChange={handleChange}>
      <BottomNavigationAction
        label="Recents"
        value="recents"
        icon={<Home />}
      />
      <BottomNavigationAction
        label="Favorites"
        value="favorites"
        icon={<FavoriteOutlined />}
      />
      <BottomNavigationAction
        label="Nearby"
        value="nearby"
        icon={<ShoppingCart />}
      />
      <BottomNavigationAction label="Folder" value="folder" icon={<Person />} />
    </BottomNavigation>
        </>
    );
}