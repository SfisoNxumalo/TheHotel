// context/AuthContext.tsx
import React, { createContext, useContext, useState, useEffect } from "react";

interface AuthState {
  token: string | null;
  email: string | null;
  role: string | null;
}

interface AuthContextValue extends AuthState {
  login: (token: string, email: string, role: string) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextValue | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [auth, setAuth] = useState<AuthState>({
    token: null,
    email: null,
    role: null,
  });

  useEffect(() => {
    const stored = localStorage.getItem("auth");
    if (stored) {
      setAuth(JSON.parse(stored));
    }
  }, []);

  const loginHandler = (token: string, email: string, role: string) => {
    const newAuth = { token, email, role };
    setAuth(newAuth);
    localStorage.setItem("auth", JSON.stringify(newAuth));
  };

  const logoutHandler = () => {
    setAuth({ token: null, email: null, role: null });
    localStorage.removeItem("auth");
  };

  return (
    <AuthContext.Provider value={{ ...auth, login: loginHandler, logout: logoutHandler }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error("useAuth must be used within AuthProvider");
  return ctx;
};
