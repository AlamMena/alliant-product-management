"use client";
import { getSession, logOut } from "@/lib/users/actions";
import { User } from "@/lib/users/types";
import {
  Navbar,
  NavbarBrand,
  NavbarContent,
  NavbarItem,
  Link,
  User as UserComponent,
} from "@heroui/react";
import { redirect, usePathname } from "next/navigation";
import { useEffect, useState } from "react";

export const AcmeLogo = () => {
  return (
    <svg fill="none" height="36" viewBox="0 0 32 32" width="36">
      <path
        clipRule="evenodd"
        d="M17.6482 10.1305L15.8785 7.02583L7.02979 22.5499H10.5278L17.6482 10.1305ZM19.8798 14.0457L18.11 17.1983L19.394 19.4511H16.8453L15.1056 22.5499H24.7272L19.8798 14.0457Z"
        fill="currentColor"
        fillRule="evenodd"
      />
    </svg>
  );
};
const routes = [
  {
    title: "Customers",
    href: "/customers",
  },
  {
    title: "Products",
    href: "/products",
  },
  {
    title: "Categories",
    href: "/categories",
  },
];
export function AppNavbar() {
  const [user, setUser] = useState<User>();
  const pathname = usePathname();
  useEffect(() => {
    const handleGetSession = async () => {
      const userSession = await getSession();
      if (userSession) {
        setUser(userSession);
      } else {
        redirect("/login");
      }
    };
    handleGetSession();
  }, [getSession]);
  return (
    <Navbar
      isBordered
      className="w-full outline outline-[0.5px] outline-slate-600 bg-slate-800 rounded-t-xl"
    >
      <NavbarBrand className="max-w-none">
        <AcmeLogo />
      </NavbarBrand>

      <NavbarContent justify="start">
        {routes.map((route) => (
          <NavbarItem isActive={pathname === route.href} key={route.title}>
            <Link
              color="primary"
              href={route.href}
              className={
                pathname === route.href
                  ? "text-white text-sm"
                  : "text-foreground-300 text-sm"
              }
            >
              {route.title}
            </Link>
          </NavbarItem>
        ))}
        <NavbarItem>
          <Link
            color="primary"
            onPress={() => logOut()}
            className={"text-foreground-300 text-sm"}
          >
            Log out
          </Link>
        </NavbarItem>
      </NavbarContent>

      <NavbarContent as="div" justify="end">
        <UserComponent
          avatarProps={{
            src: "https://cdn-icons-png.flaticon.com/128/18663/18663583.png",
          }}
          classNames={{
            name: "text-white",
          }}
          name={user?.username}
          description={user?.email}
        />
      </NavbarContent>
    </Navbar>
  );
}
