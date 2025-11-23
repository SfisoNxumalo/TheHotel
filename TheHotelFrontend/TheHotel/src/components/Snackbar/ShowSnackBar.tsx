import { Button, Snackbar, SnackbarCloseReason, SnackbarOrigin } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";

interface SnackbarProps{
    open: boolean,
    setOpen: (open:boolean) => void
    showButton: boolean,
    buttonText:string
    message:string,
    url: string
    anchorOrigin: anchorOrigin
}

export interface anchorOrigin extends SnackbarOrigin{

}

export default function ShowCustomSnackbar({open = false, setOpen, message, url, showButton, buttonText, anchorOrigin}:SnackbarProps)
{
    const navigate = useNavigate();

    const handleClose = (
    event: React.SyntheticEvent | Event,
    reason?: SnackbarCloseReason,
  ) => {
    if (reason === 'clickaway') {
        
      return;
    }
    setOpen(false)
  };
    return(
        <Snackbar
            open={open }
            anchorOrigin={anchorOrigin}
            autoHideDuration={5000}
            onClose={handleClose}
            message={message}
            action={showButton ? (
                <Button color="secondary" size="small" onClick={()=>{navigate(url)}}>
                    {buttonText}
                </Button>
                ) : null
            }
        />
    )
}