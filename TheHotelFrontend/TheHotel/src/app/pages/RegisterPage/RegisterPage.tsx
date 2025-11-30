import {
  Box,
  Button,
  Card,
  CardContent,
  CircularProgress,
  TextField,
  Typography,
} from "@mui/material";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { registerUser, registerRequest } from "../../../services/AuthService/authService";
import SuccessPopup from "../../../components/SuccessPopup/SuccessPopup";
export default function RegisterPage() {
  
  const navigate = useNavigate();

  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setLoading] = useState<boolean>(false);

  const [openSuccess, setOpenSuccess] = useState(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    setLoading(true)
    const newUser:registerRequest = {
      fullName: fullName,
      email: email,
      phoneNumber: phoneNumber,
      password: password
    }

    const res = await registerUser(newUser)

    if(res.status == 200){
      setOpenSuccess(true);
    }

    setLoading(false)
  };

  return (
    <Box
      sx={{
        minHeight: "100vh",
        position: "relative",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        background: "#ffffff",
        overflow: "hidden",
        p: 2,
      }}
    >
      {/* <LoadingComponent/> */}
      <div className="floating-circle circle-1" />
      <div className="floating-circle circle-2" />

      <Card
        sx={{
          width: "100%",
          maxWidth: 420,
          borderRadius: 4,
          boxShadow: "0 8px 25px rgba(0,0,0,0.08)",
          position: "relative",
          zIndex: 10,
        }}
        className="slide-up"
      >
        <CardContent sx={{ p: 4 }}>
          <Typography
            variant="h4"
            fontWeight={700}
            textAlign="center"
            mb={1}
            color="#3470ed"
          >
            Create Account
          </Typography>

          <Typography textAlign="center" color="text.secondary" mb={3}>
            Get started by creating your profile
          </Typography>

          <form onSubmit={handleSubmit}>
            <TextField
              fullWidth
              label="Full Name"
              variant="outlined"
              sx={{ mb: 2 }}
              required
              value={fullName}
              onChange={(e) => setFullName(e.target.value)}
            />

            <TextField
              fullWidth
              label="Email"
              variant="outlined"
              type="email"
              sx={{ mb: 2 }}
              required
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />

            <TextField
              fullWidth
              label="Phone Number"
              variant="outlined"
              sx={{ mb: 2 }}
              type="tel"
              required
              value={phoneNumber}
              onChange={(e) => setPhoneNumber(e.target.value)}
            />

            <TextField
              fullWidth
              label="Password"
              type="password"
              variant="outlined"
              sx={{ mb: 3 }}
              required
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />

            <Button
              type="submit"
              disabled={isLoading}
              fullWidth
              variant="contained"
              size="large"
              sx={{
                background: "#3470ed",
                fontWeight: 600,
                py: 1.4,
                borderRadius: 3,
                textTransform: "none",
                "&:hover": { background: "#2b5fcc" },
              }}
            >
              {!isLoading ? <label>Register</label> : <CircularProgress sx={{ color: "white" }} size={20}/>}
            </Button>
          </form>

          <Typography textAlign="center" mt={3} fontSize={14}>
            Already have an account?{" "}
            <span
              style={{ color: "#3470ed", cursor: "pointer" }}
              onClick={() => navigate("/auth/login")}
            >
              Login
            </span>
          </Typography>
        </CardContent>
      </Card>
      <SuccessPopup
        open={openSuccess}
        onClose={() => {
          setOpenSuccess(false);
        }} 
        onContinue={() => {
          setOpenSuccess(false);
          navigate('/auth/login');
        }} 
        buttonText={"Login"} 
        title={"Registration Successful!"} 
        message={"Your account has been created successfully. You can now login and start using the app."}      />
    </Box>
  );
}
