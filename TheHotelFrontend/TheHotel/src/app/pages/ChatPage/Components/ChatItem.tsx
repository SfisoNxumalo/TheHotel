import { ListItem, ListItemAvatar, Avatar, ListItemText, Typography, Divider } from "@mui/material";
import React from "react";



export default function ChatItem(){

    return (
        <><ListItem alignItems="flex-start">
            <ListItemAvatar>
                <Avatar alt="Remy Sharp" src="/static/images/avatar/1.jpg" />
            </ListItemAvatar>
            <ListItemText
                primary="Brunch this weekend?"
                secondary={<React.Fragment>
                    <Typography
                        component="span"
                        variant="body2"
                        sx={{ color: 'text.primary', display: 'inline' }}
                    >
                        Ali Connors
                    </Typography>
                    {" — I'll be in your neighborhood doing errands this…"}
                </React.Fragment>} />
        </ListItem><Divider variant="inset" component="li" /></>
    );
}