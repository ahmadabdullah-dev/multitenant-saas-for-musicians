import {
  AppBar,
  Toolbar,
  Box,
  Stack,
  Link as MuiLink,
  useTheme,
  Container,
} from "@mui/material";
import { Link as RouterLink } from "react-router";
import TemporaryDrawer from "../TemporaryDrawer/TemporaryDrawer";
import NavDropdownMenu from "./NavDrawDownMenu";
import { NAV_LINKS } from "../../shared/navLinks";
import { useEffect, useState } from "react";
import AppLogoWithName from "../global/AppLogoWithName";

export default function Header() {
  const [scrolled, setScrolled] = useState(false);
  const theme = useTheme();

  useEffect(() => {
    const onScroll = () => setScrolled(window.scrollY > 8);
    onScroll();
    window.addEventListener("scroll", onScroll, { passive: true });
    return () => window.removeEventListener("scroll", onScroll);
  }, []);

  const navLinkSx = {
    color: theme.palette.text.primary,
    fontWeight: 600,
    fontSize: 13,
    letterSpacing: "0.15em",
    textTransform: "uppercase" as const,
    "&:hover": { color: theme.palette.secondary.main },
  };

  return (
    <AppBar
      position="fixed"
      elevation={0}
      sx={{
        backgroundColor: scrolled
          ? theme.palette.background.paper
          : "transparent",
        backdropFilter: scrolled ? "blur(16px)" : "none",
        borderBottom: `1px solid ${scrolled ? theme.palette.divider : "transparent"}`,
        transition: "background-color 300ms ease, border-color 300ms ease",
        boxShadow: "none",
      }}
    >
      <Container maxWidth="lg">
        <Toolbar
          sx={{
            minHeight: { xs: 64, md: 80 },
            px: { xs: 2, md: 0 },
            justifyContent: "space-between",
            gap: 3,
          }}
        >
          <Box
            component={RouterLink}
            to="/"
            sx={{
              display: "flex",
              alignItems: "center",
              gap: 1,
              textDecoration: "none",
              flexShrink: 0,
            }}
          >
            <AppLogoWithName />
          </Box>

          <Stack
            direction="row"
            spacing={5}
            sx={{
              display: { xs: "none", md: "flex" },
              flex: 1,
              justifyContent: "center",
            }}
          >
            {NAV_LINKS.map((link) =>
              link.subItems ? (
                <NavDropdownMenu
                  key={link.label}
                  label={link.label}
                  items={link.subItems}
                />
              ) : (
                <MuiLink
                  key={link.label}
                  component={RouterLink}
                  to={link.href || "#"}
                  underline="none"
                  sx={navLinkSx}
                >
                  {link.label}
                </MuiLink>
              ),
            )}
          </Stack>

          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              gap: 3,
              marginLeft: "auto",
            }}
          >
            <MuiLink
              component={RouterLink}
              to="/contact"
              underline="none"
              sx={{
                display: { xs: "none", md: "inline-flex" },
                ...navLinkSx,
                fontSize: 12,
              }}
            >
              Contact
            </MuiLink>
            <Box sx={{ display: { xs: "flex", md: "none" } }}>
              <TemporaryDrawer items={NAV_LINKS} />
            </Box>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
