
import { toast as sonnerToast } from "sonner";
import  { Button, type ButtonProps } from "@/components/ui/inputs/button/button";

type ToastButtonProps = {
	label: string;
	onClick: () => void;
	variant?: ButtonProps["variant"];
};

export interface ToastProps {
	id: string | number;
	title: string;
	description?: string;
	icon?: React.ReactElement;
	buttons?: ToastButtonProps[] | ToastButtonProps;
}

export function toast(toastProps: Omit<ToastProps, "id">) {
	return sonnerToast.custom((id) => <Toast id={id} {...toastProps} />);
}

export function toastWithId(toastProps: ToastProps) {
	return sonnerToast.custom((_) => <Toast {...toastProps} />, { id: toastProps.id });
}

export function checkToast(id: string | number) {
	return sonnerToast.getToasts().some((toast) => toast.id === id);
}

export const Toast = (props: ToastProps) => (
	// <div className="flex gap-4 shadow-lg ring-1 w-full rounded-lg md:max-w-[364px] items-center p-4 bg-white dark:bg-black ring-black/5 dark:ring-gray-700">
	// 	{props.icon && (
	// 		<span className="w-4 h-4 [&>svg]:w-full [&>svg]:h-full dark:text-white">{props.icon}</span>
	// 	)}

	// 	<div className="flex flex-1 items-center">
	// 		<div className="w-full">
	// 			<p className="text-sm font-medium text-gray-900 dark:text-white">{props.title}</p>
	// 			<p className="mt-1 text-sm text-gray-500 dark:text-gray-300">{props.description}</p>
	// 		</div>
	// 	</div>

	// 	{props.buttons &&
	// 		(Array.isArray(props.buttons) ? props.buttons : [props.buttons]).map((button) => (
	// 			<Button
	// 				key={`${button.label}`}
	// 				onClick={() => {
	// 					button.onClick();
	// 					sonnerToast.dismiss(props.id);
	// 				}}
	// 				variant={button.variant}
	// 			>
	// 				{button.label}
	// 			</Button>
	// 		))}
	// </div>
);
