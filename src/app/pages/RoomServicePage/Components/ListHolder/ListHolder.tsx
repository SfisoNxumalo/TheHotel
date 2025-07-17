import { List, ListSubheader, ListItem, ListItemText } from "@mui/material";

export default function ListHolder(){

    return (
        <List
      sx={{
        width: '100%',
        // maxWidth: 360,
        bgcolor: 'background.paper',
        position: 'relative',
        overflow: 'auto',
        maxHeight: 800,
        '& ul': { padding: 0 },
      }}
      subheader={<li />}
    >
      {[0, 1, 2, 3,4,5,6,7,8,9,10,11,12,13,14 ,15,16,17,18,19,20,21,22,23,24,25,26,278,29].map((sectionId) => (
        <li key={`section-${sectionId}`}>
          <ul>
            <ListSubheader>{`I'm sticky ${sectionId}`}</ListSubheader>
            {[0, 1, 2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,81,9].map((item) => (
              <ListItem key={`item-${sectionId}-${item}`}>
                <ListItemText primary={`Item ${item}`} />
              </ListItem>
            ))}
          </ul>
        </li>
      ))}
    </List>
    );
}