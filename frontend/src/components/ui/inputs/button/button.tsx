import { cn } from "@/utils/cn";
import type { VariantProps } from "class-variance-authority";
import { cva } from "class-variance-authority";
import type React from "react";

const buttonVariants = cva(
	"inline-flex items-center justify-center  gap-2 whitespace-nowrap rounded-md text-sm font-medium transition-all disabled:pointer-events-none disabled:opacity-50 [&_svg]:pointer-events-none [&_svg:not([class*='size-'])]:size-4 ] [&_svg]:shrink-0 outline-none focus-visible:border-ring focus-visible:ring-ring/50 focus-visible:ring-[3px] aria-invalid:ring-destructive/20 dark:aria-invalid:ring-destructive/40 aria-invalid:border-destructive cursor-pointer",
	{
		variants: {
			variant: {
				default:
					"bg-primary-techary text-white shadow-xs hover:bg-primary-techary-dark dark:bg-primary-techary-dark dark:hover:bg-primary-techary",
				destructive:
					"bg-red-700 text-white shadow-xs hover:bg-red-800 focus-visible:ring-red-500 dark:bg-red-800 dark:hover:bg-red-900",
				outline:
					"border border-primary-lightgrey text-primary-charcoal hover:bg-primary-lightgrey hover:border-primary-charcoal dark:border-gray-600 dark:text-white dark:hover:bg-gray-700 dark:hover:border-white",
				secondary:
					"bg-primary-lightgrey text-primary-charcoal hover:bg-primary-charcoal hover:text-white dark:bg-gray-700 dark:text-white dark:hover:bg-white dark:hover:text-gray-900",
				ghost:
					"bg-transparent text-primary-techary hover:bg-primary-lightgrey dark:text-white dark:hover:bg-gray-700",
				link: "bg-transparent text-secondary-resources hover:text-secondary-resources-dark underline dark:text-blue-400 dark:hover:text-blue-300",
			},
			size: {
				default: "h-9 px-4 py-2 has-[>svg]:px-3",
				sm: "h-8 rounded-md gap-1.5 px-3 has-[>svg]:px-2.5",
				lg: "h-10 rounded-md px-6 has-[>svg]:px-4",
				icon: "size-9",
				custom: "",
			},
		},
		defaultVariants: {
			variant: "default",
			size: "default",
		},
	},
);

export interface ButtonProps
	extends React.ButtonHTMLAttributes<HTMLButtonElement>,
		VariantProps<typeof buttonVariants> {
	/** (optional) Boolean to indicate loading state  */
	isLoading?: boolean;
	text?: string;
	ref?: React.Ref<HTMLButtonElement>;
}

const Button = ({ isLoading, ...props }: ButtonProps) => (
	// Rendering a button element with dynamic classes and props
	<button
		{...props}
		className={cn(buttonVariants({ variant: props.variant, size: props.size }), props.className)}
		disabled={isLoading || props.disabled}
	>
		{isLoading ? "Loading..." : (props.text ?? props.children)}
	</button>
);

export { Button };
