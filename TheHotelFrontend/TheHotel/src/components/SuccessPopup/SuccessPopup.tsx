import {
  Dialog,
  DialogContent,
  Box,
  Typography,
  Button,
  IconButton,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";

interface Props {
  open: boolean;
  onClose: () => void;
  onContinue: () => void;
  buttonText:string;
  title:string;
  message:string
}

export default function SuccessPopup({ open, onClose, onContinue, buttonText, title, message }: Props) {
  return (
    <Dialog
      open={open}
      onClose={onClose}
      PaperProps={{
        sx: {
          borderRadius: 4,
          p: 2,
          maxWidth: 380,
          position: "relative",
        },
        className: "scale-in",
      }}
    >
      <DialogContent sx={{ textAlign: "center" }}>
        {/* Close button */}
        <IconButton
          onClick={onClose}
          sx={{ position: "absolute", top: 10, right: 10 }}
        >
          <CloseIcon />
        </IconButton>

        {/* Success Emoji/Icon */}
        <Box sx={{ fontSize: 60, mb: 1 }}>🍪</Box>

        <Typography fontSize={18} fontWeight={600} mb={1}>
          {title}
        </Typography>

        <Typography color="text.secondary" mb={3}>
          {message}
        </Typography>

        <Button
          variant="contained"
          fullWidth
          sx={{
            background: "#3470ed",
            py: 1.4,
            borderRadius: 3,
            fontWeight: 600,
            "&:hover": { background: "#295dcc" },
          }}
          onClick={onContinue}
        >
          {buttonText}
        </Button>
      </DialogContent>
    </Dialog>
  );
}
