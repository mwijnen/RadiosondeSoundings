DROP TABLE IF EXISTS
    radiosonde.radiosonde_sounding;

CREATE TABLE radiosonde.radiosonde_sounding (
    id varchar(25),
    created_date_time_stamp datetime,
	launch_site_id varchar(25),
	launch_year varchar(10),
	launch_month varchar(10),
	launch_day varchar(10),
	launch_hour varchar(10),
	launch_time varchar(10),
	number_of_levels_in_sounding varchar(10),
	cloud_information varchar(10),
	latitude varchar(25),
	longitude varchar(25),
	elevation varchar(10),
	observation_type varchar(10),
	sonde_type varchar(10),
	serial_number varchar(25),
	serial_number_type varchar(10),
	pressure_correction varchar(10),
	geopotential_height_correction varchar(10),
	temperature_correction varchar(10),
	relative_humidity_correction varchar(10),
	dew_point_correction varchar(10),
	wind_speed_and_direction_correction varchar(10)
);