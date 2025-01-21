"use client";
import {
  Navbar,
  NavbarBrand,
  NavbarContent,
  NavbarItem,
  Link,
  DropdownItem,
  DropdownTrigger,
  Dropdown,
  DropdownMenu,
  Avatar,
  User as UserComponent,
} from "@heroui/react";
import { useEffect, useState } from "react";

export const AcmeLogo = () => {
  return (
    <svg
      fill="none"
      height="36"
      viewBox="0 0 32 32"
      width="36"
      //   className="absolute top-8"
    >
      <path
        clipRule="evenodd"
        d="M17.6482 10.1305L15.8785 7.02583L7.02979 22.5499H10.5278L17.6482 10.1305ZM19.8798 14.0457L18.11 17.1983L19.394 19.4511H16.8453L15.1056 22.5499H24.7272L19.8798 14.0457Z"
        fill="currentColor"
        fillRule="evenodd"
      />
    </svg>
  );
};
export function AppNavbar() {
  return (
    <Navbar
      isBordered
      className="w-full outline outline-[0.5px] outline-slate-600 bg-slate-800 rounded-t-xl"
    >
      <NavbarBrand className="max-w-none">
        <AcmeLogo />
      </NavbarBrand>

      <NavbarContent justify="start">
        <NavbarItem isActive>
          <Link color="primary" href="#" className="text-white text-sm">
            Inicio
          </Link>
        </NavbarItem>
        <NavbarItem>
          <Link
            aria-current="page"
            color="foreground"
            href="#"
            className="text-foreground-300 text-sm"
          >
            Configuracion
          </Link>
        </NavbarItem>
        <NavbarItem>
          <Link
            aria-current="page"
            color="foreground"
            href="#"
            className="text-foreground-300 text-sm"
          >
            Cerrar sesion
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
          name="Alam Mena"
          description={"Amenabeato@gmail.com"}
        />
      </NavbarContent>
    </Navbar>
  );
}
