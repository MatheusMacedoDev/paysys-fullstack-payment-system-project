import { twMerge } from 'tailwind-merge';

export type SizeOptions = 'small' | 'medium' | 'big';

const userGreetingTextDefaultStyle = 'font-semibold text-green-300';
const userGreetingTextStyles = {
    small: 'text-md',
    medium: 'text-lg',
    big: 'text-lg'
};

const userCircleDefaultStyle =
    'rounded-full bg-green-300 flex justify-center items-center';
const userCircleSizeStyles = {
    small: 'w-12 h-12',
    medium: 'w-14 h-14',
    big: 'w-16 h-16'
};

const userIconDefaultStyle = 'text-green-950';
const userIconSizeStyles = {
    small: 'text-2xl',
    medium: 'text-[26px]',
    big: 'text-[32px]'
};

export function getUserGreetingTextStyle(size: SizeOptions) {
    return twMerge(userGreetingTextDefaultStyle, userGreetingTextStyles[size]);
}

export function getUserCircleStyle(size: SizeOptions) {
    return twMerge(userCircleDefaultStyle, userCircleSizeStyles[size]);
}

export function getUserIconStyle(size: SizeOptions) {
    return twMerge(userIconDefaultStyle, userIconSizeStyles[size]);
}
