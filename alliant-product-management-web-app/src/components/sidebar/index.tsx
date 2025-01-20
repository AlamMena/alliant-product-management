"use client";
import { Avatar, Tooltip } from "@heroui/react";
import { Icon } from "@iconify-icon/react/dist/iconify.js";

const routes = [
  {
    title: "Home",
    href: "/",
    iconName: "solar:home-2-outline",
  },
  {
    title: "Customers",
    href: "/",
    iconName: "solar:users-group-two-rounded-outline",
  },
  {
    title: "Products",
    href: "/",
    iconName: "solar:box-minimalistic-outline",
  },
];
export const AcmeLogo = () => {
  return (
    <svg
      fill="none"
      height="36"
      viewBox="0 0 32 32"
      width="36"
      className="absolute top-8"
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
export function SideBar() {
  return (
    <div className="flex flex-col items-center justify-center space-y-4 h-screen border-r-2 w-fit p-8  bg-white ">
      <AcmeLogo />
      {routes.map((route) => {
        return (
          <div key={route.title}>
            <Tooltip
              className="capitalize"
              content={route.title}
              placement="right-end"
            >
              <Icon icon={route.iconName} width={24} height={24} />
            </Tooltip>
          </div>
        );
      })}

      <Avatar
        className="absolute bottom-8"
        src="https://cdn-icons-png.flaticon.com/128/2202/2202112.png"
      />
    </div>
  );
}
