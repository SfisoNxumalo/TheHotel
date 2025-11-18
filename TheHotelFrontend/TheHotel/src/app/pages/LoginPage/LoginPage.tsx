import {
  Box,
  Button,
  Card,
  CardContent,
  TextField,
  Typography,
} from "@mui/material";
import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function LoginPage() {
  const navigate = useNavigate();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

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
      {/* Floating background elements */}
      <div className="floating-circle circle-1" />
      <div className="floating-circle circle-2" />

      {/* Login Card */}
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
            Welcome Back 👋
          </Typography>

          <Typography
            textAlign="center"
            color="text.secondary"
            mb={3}
          >
            Please sign in to continue
          </Typography>

          <TextField
            fullWidth
            label="Email"
            variant="outlined"
            sx={{ mb: 2 }}
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />

          <TextField
            fullWidth
            label="Password"
            type="password"
            variant="outlined"
            sx={{ mb: 3 }}
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />

          <Button
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
            Login
          </Button>

          <Typography
            textAlign="center"
            mt={3}
            fontSize={14}
          >
            Don’t have an account?{" "}
            <span
              style={{ color: "#3470ed", cursor: "pointer" }}
              onClick={() => navigate("/register")}
            >
              Register
            </span>
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
}
