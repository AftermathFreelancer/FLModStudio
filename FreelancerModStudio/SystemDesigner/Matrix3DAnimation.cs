﻿namespace FreelancerModStudio.SystemDesigner
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Media3D;

    public class Matrix3DAnimation : AnimationTimeline
    {
        public override Type TargetPropertyType
        {
            get
            {
                return typeof(Matrix3D);
            }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new Matrix3DAnimation();
        }

        public Matrix3D? From
        {
            get
            {
                return (Matrix3D)this.GetValue(FromProperty);
            }

            set
            {
                this.SetValue(FromProperty, value);
            }
        }

        public static DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(Matrix3D?), typeof(Matrix3DAnimation),
                new PropertyMetadata(null));

        public Matrix3D? To
        {
            get
            {
                return (Matrix3D)this.GetValue(ToProperty);
            }

            set
            {
                this.SetValue(ToProperty, value);
            }
        }

        public static DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(Matrix3D?), typeof(Matrix3DAnimation),
                new PropertyMetadata(null));

        public Matrix3DAnimation()
        {
        }

        public Matrix3DAnimation(Matrix3D toValue, Duration duration)
        {
            this.To = toValue;
            this.Duration = duration;
        }

        public Matrix3DAnimation(Matrix3D toValue, Duration duration, FillBehavior fillBehavior)
        {
            this.To = toValue;
            this.Duration = duration;
            this.FillBehavior = fillBehavior;
        }

        public Matrix3DAnimation(Matrix3D fromValue, Matrix3D toValue, Duration duration)
        {
            this.From = fromValue;
            this.To = toValue;
            this.Duration = duration;
        }

        public Matrix3DAnimation(Matrix3D fromValue, Matrix3D toValue, Duration duration, FillBehavior fillBehavior)
        {
            this.From = fromValue;
            this.To = toValue;
            this.Duration = duration;
            this.FillBehavior = fillBehavior;
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            if (animationClock.CurrentProgress == null)
            {
                return Matrix3D.Identity;
            }

            double normalizedTime = animationClock.CurrentProgress.Value;

            Matrix3D from = this.From ?? (Matrix3D)defaultOriginValue;
            Matrix3D to = this.To ?? (Matrix3D)defaultDestinationValue;

            Matrix3D newMatrix = new Matrix3D(
                ((to.M11 - from.M11)*normalizedTime) + from.M11,
                ((to.M12 - from.M12)*normalizedTime) + from.M12,
                ((to.M13 - from.M13)*normalizedTime) + from.M13,
                ((to.M14 - from.M14)*normalizedTime) + from.M14,
                ((to.M21 - from.M21)*normalizedTime) + from.M21,
                ((to.M22 - from.M22)*normalizedTime) + from.M22,
                ((to.M23 - from.M23)*normalizedTime) + from.M23,
                ((to.M24 - from.M24)*normalizedTime) + from.M24,
                ((to.M31 - from.M31)*normalizedTime) + from.M31,
                ((to.M32 - from.M32)*normalizedTime) + from.M32,
                ((to.M33 - from.M33)*normalizedTime) + from.M33,
                ((to.M34 - from.M34)*normalizedTime) + from.M34,
                ((to.OffsetX - from.OffsetX)*normalizedTime) + from.OffsetX,
                ((to.OffsetY - from.OffsetY)*normalizedTime) + from.OffsetY,
                ((to.OffsetZ - from.OffsetZ)*normalizedTime) + from.OffsetZ,
                ((to.M44 - from.M44)*normalizedTime) + from.M44);

            return newMatrix;
        }
    }
}
