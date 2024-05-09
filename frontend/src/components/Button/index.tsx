import { ButtonColor, ButtonSize, getMergedStyle } from './styleOptions';

interface ButtonProps {
    title: string;
    buttonColor?: ButtonColor;
    buttonSize?: ButtonSize;
    className?: string;
    actionFn?: () => void;
}

export default function Button({
    title,
    buttonColor = 'light',
    buttonSize = 'small',
    className,
    actionFn
}: ButtonProps) {
    const style = getMergedStyle(buttonColor, buttonSize, className);

    return (
        <button type="button" onClick={actionFn} className={style}>
            {title}
        </button>
    );
}
