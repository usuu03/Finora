import { type ToasterProps as SonnerToasterProps, Toaster as ToasterSonner } from "sonner";

export type ToasterProps = SonnerToasterProps;

export const Toaster = (props: ToasterProps) => <ToasterSonner {...props} />;