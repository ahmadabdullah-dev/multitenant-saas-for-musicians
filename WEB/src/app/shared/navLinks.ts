export interface MenuItem {
  label?: string;
  href?: string;
  category?: string;
  description?: string;
}
export interface NavLink {
  label: string;
  href?: string;
  subItems?: MenuItem[];
}

export const NAV_LINKS: NavLink[] = [
  {
    label: "Product",
    subItems: [
      {
        label: "Distribution",
        href: "/product/distribution",
        description: "Release to every major streaming platform",
      },
      {
        label: "Fan Pages",
        href: "/product/fan-pages",
        description: "A branded home for every artist",
      },
      {
        label: "Merch & Tickets",
        href: "/product/commerce",
        description: "Sell products and shows to your fans",
      },
      {
        label: "Royalty Splits",
        href: "/product/royalty-splits",
        description: "Automated payouts for collaborators",
      },
    ],
  },
  {
    label: "Solutions",
    subItems: [
      {
        label: "Independent Artists",
        href: "/solutions/independent-artists",
        description: "Everything you need to go it alone",
      },
      {
        label: "Labels & Managers",
        href: "/solutions/labels",
        description: "Manage multiple artists in one place",
      },
    ],
  },
  { label: "Pricing", href: "/pricing" },
  { label: "Blog", href: "/blog" },
];
