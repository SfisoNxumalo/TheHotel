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
import { loginRequest, loginUser } from "../../../services/AuthService/authService";
import { useAuthStore } from "../../../stores/authStore";
import { AuthUser } from "../../../Interfaces/AuthUser";

export default function LoginPage() {
  const navigate = useNavigate();
  const login = useAuthStore.getState().login; // or use selector
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setLoading] = useState<boolean>(false);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    setLoading(true)

    const logUser:loginRequest = {
      email:email,
      password:password
    }

    const res = await loginUser(logUser)

    if(res.status == 200){
      const user:AuthUser = res.data
      login(user)

      if(user.role === 'Staff'){
        navigate('/admin/dashboard')
      }
      else{
        navigate('/dashboard')
      }

      setLoading(false)
      
    }
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
      {/* {<LoadingComponent/>} */}
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
            Welcome Back
          </Typography>

          <Typography textAlign="center" color="text.secondary" mb={3}>
            Please sign in to continue
          </Typography>

          {/* FORM STARTS */}
          <form onSubmit={handleSubmit}>
            <TextField
              fullWidth
              label="Email"
              variant="outlined"
              type="email"
              sx={{ mb: 2 }}
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />

            <TextField
              fullWidth
              label="Password"
              type="password"
              variant="outlined"
              sx={{ mb: 3 }}
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />

            <Button
              disabled={isLoading}
              fullWidth
              type="submit"
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
              {!isLoading ? <label>Login</label> : <CircularProgress  sx={{ color: "white" }} size={20}/>}
            </Button>
          </form>
          {/* FORM ENDS */}

          <Typography textAlign="center" mt={3} fontSize={14}>
            Don’t have an account?{" "}
            <span
              style={{ color: "#3470ed", cursor: "pointer" }}
              onClick={() => navigate("/auth/register")}
            >
              Register
            </span>
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
}
