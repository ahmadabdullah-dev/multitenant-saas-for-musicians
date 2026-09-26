import { Box, Container, Grid, Link, Stack, Typography } from "@mui/material";
import { Link as RouterLink } from "react-router";
import AppLogoWithName from "../global/AppLogoWithName";

const footerLinks = [
  {
    title: "Product",
    links: [
      { label: "Overview", href: "/product" },
      { label: "Pricing", href: "/pricing" },
    ],
  },
  {
    title: "Developers",
    links: [{ label: "API & SDKs", href: "/for-developers" }],
  },
  {
    title: "Support",
    links: [
      { label: "Contact", href: "/contact" },
      { label: "FAQ", href: "/faq" },
    ],
  },
];

export default function Footer() {
  return (
    <Box
      component="footer"
      sx={{
        mt: 12,
        pt: 6,
        pb: 4,
        borderTop: "1px solid",
        borderColor: "divider",
      }}
    >
      <Container maxWidth="lg">
        <Grid container spacing={{ xs: 4, md: 5 }}>
          {/* Brand column */}
          <Grid size={{ xs: 12, sm: 12, md: 5 }}>
            <Link
              component={RouterLink}
              to="/"
              underline="none"
              sx={{ display: "inline-flex", alignItems: "center" }}
            >
              <AppLogoWithName />
            </Link>

            <Typography
              sx={{
                mt: 1.5,
                fontSize: 13.5,
                lineHeight: 1.65,
                color: "text.secondary",
                maxWidth: "36ch",
              }}
            >
              Lorem ipsum dolor sit amet consectetur adipisicing elit. Officiis
              labore laborum maiores odio hic placeat? Ab optio quae, maxime
              reiciendis cumque quas quod, quasi facilis suscipit corrupti ut
              veritatis consectetur.
            </Typography>
          </Grid>

          {/* Link columns */}
          {footerLinks.map((col) => (
            <Grid size={{ xs: 6, sm: 4, md: 2.33 }} key={col.title}>
              <Typography
                sx={{
                  fontFamily: "monospace",
                  fontSize: 10,
                  fontWeight: 600,
                  letterSpacing: "0.13em",
                  textTransform: "uppercase",
                  color: "text.secondary",
                  mb: 1.75,
                }}
              >
                {col.title}
              </Typography>

              <Stack spacing={1.1}>
                {col.links.map((link) => (
                  <Link
                    key={link.label}
                    component={RouterLink}
                    to={link.href}
                    underline="none"
                    sx={{
                      fontSize: 13.5,
                      color: "text.secondary",
                      width: "fit-content",
                      transition: "color 0.15s ease",
                      "&:hover": { color: "text.primary" },
                    }}
                  >
                    {link.label}
                  </Link>
                ))}
              </Stack>
            </Grid>
          ))}
        </Grid>

        <Box
          sx={{
            mt: 6,
            pt: 3,
            borderTop: "1px solid",
            borderColor: "divider",
            display: "flex",
            flexDirection: { xs: "column", sm: "row" },
            alignItems: { xs: "flex-start", sm: "center" },
            justifyContent: "space-between",
            gap: 1,
          }}
        >
          <Typography sx={{ fontSize: 12.5, color: "text.secondary" }}>
            © {new Date().getFullYear()} Tadriby Coach. All rights reserved.
          </Typography>

          <Stack direction="row" spacing={2.5}>
            <Link
              component={RouterLink}
              to="/privacy"
              underline="none"
              sx={{
                fontSize: 12.5,
                color: "text.secondary",
                "&:hover": { color: "text.primary" },
              }}
            >
              Privacy
            </Link>
            <Link
              component={RouterLink}
              to="/terms"
              underline="none"
              sx={{
                fontSize: 12.5,
                color: "text.secondary",
                "&:hover": { color: "text.primary" },
              }}
            >
              Terms
            </Link>
          </Stack>
        </Box>
      </Container>
    </Box>
  );
}
